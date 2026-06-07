//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'pos_dto.g.dart';

abstract class PosDto implements Built<PosDto, PosDtoBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'name')
    String get name;

    @BuiltValueField(wireName: r'branchId')
    String get branchId;

    @BuiltValueField(wireName: r'storeId')
    String get storeId;

    @BuiltValueField(wireName: r'active')
    bool get active;

    PosDto._();

    static void _initializeBuilder(PosDtoBuilder b) => b;

    factory PosDto([void updates(PosDtoBuilder b)]) = _$PosDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<PosDto> get serializer => _$PosDtoSerializer();
}

class _$PosDtoSerializer implements StructuredSerializer<PosDto> {

    @override
    final Iterable<Type> types = const [PosDto, _$PosDto];
    @override
    final String wireName = r'PosDto';

    @override
    Iterable<Object> serialize(Serializers serializers, PosDto object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'id')
            ..add(serializers.serialize(object.id,
                specifiedType: const FullType(String)));
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'name')
            ..add(serializers.serialize(object.name,
                specifiedType: const FullType(String)));
        result
            ..add(r'branchId')
            ..add(serializers.serialize(object.branchId,
                specifiedType: const FullType(String)));
        result
            ..add(r'storeId')
            ..add(serializers.serialize(object.storeId,
                specifiedType: const FullType(String)));
        result
            ..add(r'active')
            ..add(serializers.serialize(object.active,
                specifiedType: const FullType(bool)));
        return result;
    }

    @override
    PosDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = PosDtoBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'id':
                    result.id = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'name':
                    result.name = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'branchId':
                    result.branchId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'storeId':
                    result.storeId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'active':
                    result.active = serializers.deserialize(value,
                        specifiedType: const FullType(bool)) as bool;
                    break;
            }
        }
        return result.build();
    }
}

