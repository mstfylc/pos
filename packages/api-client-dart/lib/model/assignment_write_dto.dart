//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'assignment_write_dto.g.dart';

abstract class AssignmentWriteDto implements Built<AssignmentWriteDto, AssignmentWriteDtoBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'assignmentTableType')
    int get assignmentTableType;

    @BuiltValueField(wireName: r'recordIds')
    BuiltList<String> get recordIds;

    AssignmentWriteDto._();

    static void _initializeBuilder(AssignmentWriteDtoBuilder b) => b;

    factory AssignmentWriteDto([void updates(AssignmentWriteDtoBuilder b)]) = _$AssignmentWriteDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<AssignmentWriteDto> get serializer => _$AssignmentWriteDtoSerializer();
}

class _$AssignmentWriteDtoSerializer implements StructuredSerializer<AssignmentWriteDto> {

    @override
    final Iterable<Type> types = const [AssignmentWriteDto, _$AssignmentWriteDto];
    @override
    final String wireName = r'AssignmentWriteDto';

    @override
    Iterable<Object> serialize(Serializers serializers, AssignmentWriteDto object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'userId')
            ..add(serializers.serialize(object.userId,
                specifiedType: const FullType(String)));
        result
            ..add(r'assignmentTableType')
            ..add(serializers.serialize(object.assignmentTableType,
                specifiedType: const FullType(int)));
        result
            ..add(r'recordIds')
            ..add(serializers.serialize(object.recordIds,
                specifiedType: const FullType(BuiltList, [FullType(String)])));
        return result;
    }

    @override
    AssignmentWriteDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = AssignmentWriteDtoBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'userId':
                    result.userId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'assignmentTableType':
                    result.assignmentTableType = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'recordIds':
                    result.recordIds.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(String)])) as BuiltList<String>);
                    break;
            }
        }
        return result.build();
    }
}

