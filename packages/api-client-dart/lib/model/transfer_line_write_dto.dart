//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:mansis_pos_api_client/model/model_null.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'transfer_line_write_dto.g.dart';

abstract class TransferLineWriteDto implements Built<TransferLineWriteDto, TransferLineWriteDtoBuilder> {

    @BuiltValueField(wireName: r'productId')
    String get productId;

    @BuiltValueField(wireName: r'quantity')
    int get quantity;

    @nullable
    @BuiltValueField(wireName: r'unit')
    OneOfnullinteger get unit;

    @nullable
    @BuiltValueField(wireName: r'unitPrice')
    double get unitPrice;

    TransferLineWriteDto._();

    static void _initializeBuilder(TransferLineWriteDtoBuilder b) => b;

    factory TransferLineWriteDto([void updates(TransferLineWriteDtoBuilder b)]) = _$TransferLineWriteDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<TransferLineWriteDto> get serializer => _$TransferLineWriteDtoSerializer();
}

class _$TransferLineWriteDtoSerializer implements StructuredSerializer<TransferLineWriteDto> {

    @override
    final Iterable<Type> types = const [TransferLineWriteDto, _$TransferLineWriteDto];
    @override
    final String wireName = r'TransferLineWriteDto';

    @override
    Iterable<Object> serialize(Serializers serializers, TransferLineWriteDto object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'productId')
            ..add(serializers.serialize(object.productId,
                specifiedType: const FullType(String)));
        result
            ..add(r'quantity')
            ..add(serializers.serialize(object.quantity,
                specifiedType: const FullType(int)));
        result
            ..add(r'unit')
            ..add(object.unit == null ? null : serializers.serialize(object.unit,
                specifiedType: const FullType(OneOfnullinteger)));
        result
            ..add(r'unitPrice')
            ..add(object.unitPrice == null ? null : serializers.serialize(object.unitPrice,
                specifiedType: const FullType(double)));
        return result;
    }

    @override
    TransferLineWriteDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = TransferLineWriteDtoBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'productId':
                    result.productId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'quantity':
                    result.quantity = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'unit':
                    result.unit.replace(serializers.deserialize(value,
                        specifiedType: const FullType(OneOfnullinteger)) as OneOfnullinteger);
                    break;
                case r'unitPrice':
                    result.unitPrice = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
            }
        }
        return result.build();
    }
}

